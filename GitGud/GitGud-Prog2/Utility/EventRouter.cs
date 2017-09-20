using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EventRouter
{
    /// <summary>
    /// 	Event data class, passed in to the subscriber whenever an event occours.
    /// </summary>
    public class Event
    {
        public string Type;
        public string Id;
        public object[] Data;

        public bool HasData
        {
            get { return Data != null && Data.Length > 0; }
        }

        public T GetData<T>(int index)
        {
            return (T)Data[index];
        }
    }

    public delegate void Handler(Event e);

    public static bool LogEvents = false;

    static Dictionary<string, Dictionary<string, Handler>> handlers = new Dictionary<string, Dictionary<string, Handler>>();
    static Dictionary<object, Dictionary<string, Handler>> owners = new Dictionary<object, Dictionary<string, Handler>>(); // For unsubscribing via object reference
    static Queue<Event> queuedEvents = new Queue<Event>();

    /// <summary>
    /// Subscribe to the event specified by evt.  Pass in a delegate to be called back when the even occurs.
    /// </summary>
    /// <param name='evt'>
    /// The event enumeration value.
    /// </param>
    /// <param name='h'>
    /// The delegate to be called when the even occurs.
    /// </param>
    public static void Subscribe(Enum evt, Handler h, object owner = null)
    {
        Subscribe("", EnumValueToString(evt), h, owner);
    }

    /// <summary>
    /// Subscribe to the event specified by evt filtered by the specified id.  Pass in a delegate to be called back when the even occurs.
    /// </summary>
    /// <param name='id'>
    /// The id of the event
    /// </param>
    /// <param name='evt'>
    /// The event enumeration value.
    /// </param>
    /// <param name='h'>
    /// The delegate to be called when the even occurs.
    /// </param>
    public static void Subscribe(string id, Enum evt, Handler h, object owner = null)
    {
        Subscribe(id, EnumValueToString(evt), h, owner);
    }

    /// <summary>
    /// Subscribe to the event specified by evt.  Pass in a delegate to be called back when the even occurs.
    /// </summary>
    /// <param name='id'>
    /// The string representing the id.
    /// </param>
    /// <param name='evt'>
    /// The string representing the event.
    /// </param>
    /// <param name='h'>
    /// The delegate to be called when the even occurs.
    /// </param>
    public static void Subscribe(string id, string evt, Handler h, object owner = null)
    {
        if (!handlers.ContainsKey(evt))
        {
            handlers.Add(evt, new Dictionary<string, Handler>());
        }

        if (!handlers[evt].ContainsKey(id))
        {
            handlers[evt].Add(id, null);
        }

        if (owner != null)
        {
            if (!owners.ContainsKey(owner))
            {
                owners.Add(owner, new Dictionary<string, Handler>());
            }

            owners[owner].Add(evt, h);
        }

        handlers[evt][id] += h;
    }

    /// <summary>
    /// Subscribe to the event specified by evt.  Pass in a delegate to be called back when the even occurs.
    /// </summary>
    /// <param name='evt'>
    /// The string representing the event.
    /// </param>
    /// <param name='h'>
    /// The delegate to be called when the even occurs.
    /// </param>
    public static void Subscribe(string evt, Handler h, object owner = null)
    {
        Subscribe("", evt, h, owner);
    }

    /// <summary>
    /// Unsubscribe the specified delegate from the event.
    /// </summary>
    /// <param name='id'>
    /// The id of the event
    /// </param>
    /// <param name='evt'>
    /// The event enumeration value.
    /// </param>
    /// <param name='h'>
    /// The delegate to be removed from the event handlers.
    /// </param>
    public static void Unsubscribe(string id, Enum evt, Handler h)
    {
        Unsubscribe(id, EnumValueToString(evt), h);
    }

    /// <summary>
    /// Unsubscribe the specified delegate from the event.
    /// </summary>
    /// <param name='evt'>
    /// The event enumeration value.
    /// </param>
    /// <param name='h'>
    /// The delegate to be removed from the event handlers.
    /// </param>
    public static void Unsubscribe(Enum evt, Handler h)
    {
        Unsubscribe(EnumValueToString(evt), h);
    }

    /// <summary>
    /// Unsubscribe the specified delegate from the event.
    /// </summary>
    /// <param name='evt'>
    /// The string representing the event.
    /// </param>
    /// <param name='h'>
    /// The delegate to be removed from the event handlers.
    /// </param>
    public static void Unsubscribe(string evt, Handler h)
    {
        Unsubscribe("", evt, h);
    }

    /// <summary>
    /// Unsubscribe the specified delegate from the event.
    /// </summary>
    /// <param name='id'>
    /// The string representing the id.
    /// </param>
    /// <param name='evt'>
    /// The string representing the event.
    /// </param>
    /// <param name='h'>
    /// The delegate to be removed from the event handlers.
    /// </param>
    public static void Unsubscribe(string id, string evt, Handler h)
    {
        if (handlers.ContainsKey(evt) && handlers[evt].ContainsKey(id))
        {
            handlers[evt][id] -= h;
            if (handlers[evt][id] == null) handlers.Remove(evt);
        }
    }

    /// <summary>
    /// Unsubscribe to all events that were subscribed to by a specific owner object.
    /// </summary>
    /// <param name="owner">The object that subscribed to the object.</param>
    public static void Unsubscribe(object owner)
    {
        if (owners.ContainsKey(owner))
        {
            foreach (var kv in owners[owner])
            {
                Unsubscribe(kv.Key, kv.Value);
            }
            owners.Remove(owner);
        }
    }

    /// <summary>
    /// Publish the specified event with extra data.
    /// </summary>
    /// <param name='id'>
    /// The string representing the object.
    /// </para>
    /// <param name='evt'>
    /// The string representing the event.
    /// </param>
    /// <param name='data'>
    /// An arbitrary params array of objects to be interpreted by the receiver of the event.
    /// </param>
    public static void Publish(string id, string evt, params object[] data)
    {
        //if (LogEvents) Debug.Log(string.Format("Event Published: '{0}' with id: '{1}' and {2} parameters", evt, id, data.Length));

        ProcessEvent(id, evt, data);

        while (queuedEvents.Count > 0)
        {
            var queuedEvent = queuedEvents.Dequeue();
            ProcessEvent(queuedEvent.Id, queuedEvent.Type, queuedEvent.Data);
        }
    }

    /// <summary>
    /// Publish the specified event with extra data.
    /// </summary>
    /// <param name='evt'>
    /// The string representing the event.
    /// </param>
    /// <param name='data'>
    /// An arbitrary params array of objects to be interpreted by the receiver of the event.
    /// </param>
    public static void Publish(string evt, params object[] data)
    {
        Publish("", evt, data);
    }

    /// <summary>
    /// Publish the specified event with extra data.
    /// </summary>
    /// <param name='id'>
    /// The string representing the object.
    /// </para>
    /// <param name='evt'>
    /// The event enumeration value.
    /// </param>
    /// <param name='data'>
    /// An arbitrary params array of objects to be interpreted by the receiver of the event.
    /// </param>
    public static void Publish(string id, Enum evt, params object[] data)
    {
        Publish(id, EnumValueToString(evt), data);
    }

    /// <summary>
    /// Publish the specified event with extra data.
    /// </summary>
    /// <param name='evt'>
    /// The event enumeration value.
    /// </param>
    /// <param name='data'>
    /// An arbitrary params array of objects to be interpreted by the receiver of the event.
    /// </param>
    public static void Publish(Enum evt, params object[] data)
    {
        Publish(EnumValueToString(evt), data);
    }

    public static void Queue(string id, string evt, params object[] data)
    {
        var e = new Event { Type = evt, Id = id };
        if (data != null && data.Length > 0) e.Data = data;
        queuedEvents.Enqueue(e);
    }

    public static void Queue(string evt, params object[] data)
    {
        Queue(string.Empty, evt, data);
    }

    public static void Queue(string id, Enum evt, params object[] data)
    {
        Queue(id, EnumValueToString(evt), data);
    }

    public static void Queue(Enum evt, params object[] data)
    {
        Queue(string.Empty, EnumValueToString(evt), data);
    }

    /// <summary>
    /// Clear all event subscribers, used primarily when switching or resetting a level.
    /// </summary>
    public static void Clear()
    {
        handlers.Clear();
    }

    static void ProcessEvent(string id, string evt, params object[] data)
    {
        Dictionary<string, Handler> handlersForType;
        if (handlers.TryGetValue(evt, out handlersForType))
        {
            Handler handler;
            if (handlersForType.TryGetValue(id, out handler))
            {
                var e = new Event { Type = evt, Id = id };
                if (data != null && data.Length > 0) e.Data = data;
                handler(e);
            }

            // invoke handlers that don't care about a particular id
            if (id != string.Empty && handlersForType.TryGetValue(string.Empty, out handler))
            {
                var e = new Event { Type = evt, Id = id };
                if (data != null && data.Length > 0) e.Data = data;
                handler(e);
            }
        }
    }

    static string EnumValueToString(Enum value)
    {
        return string.Format("{0}.{1}", value.GetType(), value);
    }
}