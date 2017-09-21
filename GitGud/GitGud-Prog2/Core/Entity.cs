using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitGud_Prog2
{
    public class Entity
    {
        #region Private Fields

        List<Component> componentsToRemove = new List<Component>();
        List<Component> componentsToAdd = new List<Component>();

        bool updatedOnce = false;

        #endregion

        #region Private Methods

        void RenderEntity()
        {
            foreach (Component c in Components)
            {
                if (!c.RenderAfterEntity)
                {
                    c.Render();
                }
            }

            foreach (Graphic g in Graphics)
            {
                g.Render(X, Y);
            }

            Render();

            if (OnRender != null)
            {
                OnRender();
            }

            foreach (Component c in Components)
            {
                if (c.RenderAfterEntity)
                {
                    c.Render();
                }
            }
        }

        #endregion

        #region Public Fields

        /// <summary>
        /// The X position of the entity.
        /// </summary>
        public float X;

        /// <summary>
        /// The Y position of the entity.
        /// </summary>
        public float Y;

        /// <summary>
        /// How long the entity has been active.
        /// </summary>
        public float Timer;

        /// <summary>
        /// Determines if the entity will render.
        /// </summary>
        public bool Visible = true;

        /// <summary>
        /// Determines if the entity will collide with other entities. The entity can still check for
        /// collisions, but will not register as a collision with other entities.
        /// </summary>
        public bool Collidable = true;

        /// <summary>
        /// Deteremines if the entity's update functions will run automatically from the Scene.
        /// </summary>
        public bool AutoUpdate = true;

        /// <summary>
        /// Determines if the entiti's render functions will run automatically from the Scene.
        /// </summary>
        public bool AutoRender = true;

        /// <summary>
        /// The tween manager that controls all tweens on this entity.
        /// </summary>
        public GlideManager Tweener = new GlideManager();

        /// <summary>
        /// An action that fires when the entity is added to a Scene.
        /// </summary>
        public Action OnAdded;

        /// <summary>
        /// An action that fires when the entity is updated.
        /// </summary>
        public Action OnUpdate;

        /// <summary>
        /// An action that fires in the entity's UpdateFirst().
        /// </summary>
        public Action OnUpdateFirst;

        /// <summary>
        /// An action that is fired in the entity's UpdateLast().
        /// </summary>
        public Action OnUpdateLast;

        /// <summary>
        /// An action that fires when the entity is removed from a Scene.
        /// </summary>
        public Action OnRemoved;

        /// <summary>
        /// An action that fires when the entity is rendered.
        /// </summary>
        public Action OnRender;

        /// <summary>
        /// The name of this entity. Default's to the Type name.
        /// </summary>
        public string Name;

        /// <summary>
        /// The order in which to render this entity.  Higher numbers draw later.
        /// </summary>
        public int Layer;

        /// <summary>
        /// The order in which to update this entity.  Higher numbers update later.
        /// </summary>
        public int Order;

        /// <summary>
        /// The pause group this entity is a part of.
        /// </summary>
        public int Group;

        /// <summary>
        /// How long the entity should live in the scene before removing itself. If this is set the
        /// entity will be automatically removed when the Timer exceeds this value.
        /// </summary>
        public int LifeSpan;

        #endregion

        #region Public Properties

        /// <summary>
        /// The list of graphics to render.
        /// </summary>
        public List<Graphic> Graphics { get; private set; }

        /// <summary>
        /// The list of components to update and render.
        /// </summary>
        public List<Component> Components { get; private set; }

        /// <summary>
        /// The list of colliders to use for collision checks.
        /// </summary>
        public List<Collider> Colliders { get; private set; }

        /// <summary>
        /// The list of surfaces the entity should draw to.
        /// </summary>
        public List<Surface> Surfaces { get; private set; }

        /// <summary>
        /// The Scene that controls and updates this entity.
        /// </summary>
        public Scene Scene { get; internal set; }

        /// <summary>
        /// Returns true if the entity is currently in a Scene.
        /// </summary>
        public bool IsInScene
        {
            get
            {
                return Scene != null;
            }
        }

        /// <summary>
        /// The default Surface that the entity should render to.
        /// </summary>
        public Surface Surface
        {
            get
            {
                if (Surfaces == null) return null;
                if (Surfaces.Count == 0) return null;
                return Surfaces[Surfaces.Count - 1];
            }
            set
            {
                Surfaces.Clear();
                Surfaces.Add(value);
            }
        }

        /// <summary>
        /// The currently overlapped entity.  This only works when using an Overlap collision check, and there is a result.
        /// </summary>
        public Entity Overlapped { get; private set; }

        /// <summary>
        /// Set to a collider by using the SetHitbox method.  Shortcut reference.
        /// </summary>
        public Collider Hitbox { get; private set; }

        /// <summary>
        /// Returns the first available collider, or set the Collider.
        /// </summary>
        public Collider Collider
        {
            get
            {
                if (Colliders.Count == 0) return null;
                return Colliders[0];
            }
            set { SetCollider(value); }
        }

        /// <summary>
        /// A reference to the Input object in the Game that controls the Scene.
        /// </summary>
        public Input Input
        {
            get { return Scene.Game.Input; }
        }

        /// <summary>
        /// A reference to the Game that controls the Scene.
        /// </summary>
        public Game Game
        {
            get { return Scene.Game; }
        }

        /// <summary>
        /// If the entity is currently paused by the scene.
        /// </summary>
        public bool IsPaused
        {
            get
            {
                if (Scene != null)
                {
                    return Scene.IsGroupPaused(Group);
                }
                return false;
            }
        }

        /// <summary>
        /// The x position in screen space of the entity.
        /// </summary>
        public float ScreenX
        {
            get
            {
                if (Scene != null)
                {
                    return X + Scene.CameraX;
                }
                return X;
            }
        }

        /// <summary>
        /// The y position in screen space of the entity.
        /// </summary>
        public float ScreenY
        {
            get
            {
                if (Scene != null)
                {
                    return Y + Scene.CameraY;
                }
                return Y;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Create an entity.
        /// </summary>
        /// <param name="x">The x position to place the entity.</param>
        /// <param name="y">The y position to place the entity.</param>
        /// <param name="graphic">The graphic to assign to the entity.  Defaults to null.</param>
        /// <param name="collider">The collider to assign to the entity.  Defaults to null.</param>
        /// <param name="name">The name of the entity. Defaults to the type name.</param>
        public Entity(float x = 0, float y = 0, Graphic graphic = null, Collider collider = null, string name = "")
        {
            X = x;
            Y = y;

            Graphics = new List<Graphic>();
            Components = new List<Component>();
            Colliders = new List<Collider>();
            Surfaces = new List<Surface>();

            if (graphic != null)
            {
                Graphic = graphic;
            }

            if (collider != null)
            {
                Collider = collider;
            }

            if (name == "")
            {
                Name = this.GetType().Name;
            }
            else
            {
                Name = name;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the graphic to a new graphic, removing all previous graphics.
        /// </summary>
        /// <param name="g"></param>
        public void SetGraphic(Graphic g)
        {
            Graphics.Clear();
            Graphics.Add(g);
        }

        /// <summary>
        /// Set the X and Y position to a value.
        /// </summary>
        /// <param name="xy">The value of the X and Y position.</param>
        public void SetPosition(float xy)
        {
            X = Y = xy;
        }

        /// <summary>
        /// Add to the X and Y positions of the entity.
        /// </summary>
        /// <param name="x">The amount to add to the x position.</param>
        /// <param name="y">The amount to add to the y position.</param>
        public void AddPosition(float x, float y)
        {
            X += x;
            Y += y;
        }

        /// <summary>
        /// Add to the X and Y position of the entity.
        /// </summary>
        /// <param name="axis">The axis to add from.</param>
        /// <param name="multiplier">The amount to muliply the axis values by before adding.</param>
        public void AddPosition(Axis axis, float multiplier = 1)
        {
            X += axis.X * multiplier;
            Y += axis.Y * multiplier;
        }

        /// <summary>
        /// Set the position of the entity.
        /// </summary>
        /// <param name="x">The new x position.</param>
        /// <param name="y">The new y position.</param>
        public void SetPosition(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Set the position of the entity.
        /// </summary>
        /// <param name="v">The vector of the new position.</param>
        public void SetPosition(Vector2 v)
        {
            X = (float)v.X;
            Y = (float)v.Y;
        }

        /// <summary>
        /// Adds a graphic to the entity.
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public T AddGraphic<T>(T g) where T : Graphic
        {
            Graphics.Add(g);
            return g;
        }

        /// <summary>
        /// Adds the graphics to the entity.
        /// </summary>
        /// <param name="graphics"></param>
        public List<Graphic> AddGraphics(params Graphic[] graphics)
        {
            var r = new List<Graphic>();
            foreach (var g in graphics)
            {
                r.Add(AddGraphic(g));
            }
            return r;
        }

        /// <summary>
        /// Adds a graphic to the Entity and sets its Scroll value to 0.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="g">The graphic to add.</param>
        /// <returns>The added graphic.</returns>
        public T AddGraphicGUI<T>(T g) where T : Graphic
        {
            g.Scroll = 0;
            return AddGraphic(g);
        }

        /// <summary>
        /// Adds graphics to the Entity and sets their Scroll values to 0.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphics">The graphics to add.</param>
        /// <returns>The added graphics.</returns>
        public List<Graphic> AddGraphicsGUI(params Graphic[] graphics)
        {
            var r = new List<Graphic>();
            foreach (var g in graphics)
            {
                r.Add(AddGraphicGUI(g));
            }
            return r;
        }

        /// <summary>
        /// Removes a graphic from the entity.
        /// </summary>
        /// <param name="g"></param>
        public T RemoveGraphic<T>(T g) where T : Graphic
        {
            Graphics.Remove(g);
            return g;
        }

        /// <summary>
        /// Remove all the graphics from the entity.
        /// </summary>
        public void ClearGraphics()
        {
            Graphics.Clear();
        }

        /// <summary>
        /// Adds a component to the entity.
        /// </summary>
        /// <param name="c"></param>
        public T AddComponent<T>(T c) where T : Component
        {
            if (c.Entity != null) return c;
            componentsToAdd.Add(c);
            c.Entity = this;
            c.Added();
            return c;
        }

        /// <summary>
        /// Add multiple components to the entity.
        /// </summary>
        /// <param name="c">The components to add.</param>
        /// <returns>A list of the added components.</returns>
        public List<Component> AddComponents(params Component[] c)
        {
            var r = new List<Component>();
            foreach (Component com in c)
            {
                r.Add(AddComponent(com));
            }
            return r;
        }

        /// <summary>
        /// Removes a component from the entity.
        /// </summary>
        /// <param name="c"></param>
        public T RemoveComponent<T>(T c) where T : Component
        {
            componentsToRemove.Add(c);
            c.Removed();
            c.Entity = null;
            return c;
        }

        /// <summary>
        /// Remove all components from the Entity.
        /// </summary>
        public void ClearComponents()
        {
            foreach (var c in Components)
            {
                RemoveComponent(c);
            }
        }

        /// <summary>
        /// Returns the first available graphic, or set the graphic.
        /// </summary>
        public Graphic Graphic
        {
            get
            {
                if (Graphics.Count == 0) return null;
                return Graphics[0];
            }
            set { SetGraphic(value); }
        }

        /// <summary>
        /// Add a surface that the entity should render to.
        /// </summary>
        /// <param name="target"></param>
        public void AddSurface(Surface target)
        {
            Surfaces.Add(target);
        }

        /// <summary>
        /// Remove a surface from the list of surfaces that the entity should render to.
        /// </summary>
        /// <param name="target"></param>
        public void RemoveSurface(Surface target)
        {
            Surfaces.Remove(target);
        }

        /// <summary>
        /// Remove all Surfaces from the list of Surfaces that the Entity should render to.
        /// </summary>
        public void ClearSurfaces()
        {
            Surfaces.Clear();
        }

        /// <summary>
        /// Shortcut to set the Collider of the entity to a BoxCollider.
        /// </summary>
        /// <param name="width">The width of the box collider.</param>
        /// <param name="height">The height of the box collider.</param>
        /// <param name="tags">The tags assigned to the box collider.</param>
        /// <returns>The created box collider.</returns>
        public BoxCollider SetHitbox(int width, int height, params int[] tags)
        {
            var hitbox = new BoxCollider(width, height, tags);
            SetCollider(hitbox);
            Hitbox = hitbox;
            return hitbox;
        }

        /// <summary>
        /// Get the first component of type T.
        /// </summary>
        /// <typeparam name="T">The type of component to look for.</typeparam>
        /// <returns>The component.</returns>
        public T GetComponent<T>() where T : Component
        {
            foreach (Component c in Components)
            {
                if (c is T) return (T)c;
            }
            return null;
        }

        /// <summary>
        /// Get the first graphic of type T.
        /// </summary>
        /// <typeparam name="T">The type of graphic to look for.</typeparam>
        /// <returns>The graphic.</returns>
        public T GetGraphic<T>() where T : Graphic
        {
            foreach (Graphic g in Graphics)
            {
                if (g is T) return (T)g;
            }
            return null;
        }

        /// <summary>
        ///  Get the first collider of type T.
        /// </summary>
        /// <typeparam name="T">The type of collider to look for.</typeparam>
        /// <returns>The collider.</returns>
        public T GetCollider<T>() where T : Collider
        {
            foreach (Collider c in Colliders)
            {
                if (c is T) return (T)c;
            }
            return null;
        }

        /// <summary>
        /// Add a collider to the entity.
        /// </summary>
        /// <param name="c"></param>
        public T AddCollider<T>(T c) where T : Collider
        {
            Colliders.Add(c);
            c.Entity = this;
            c.Added();
            if (Scene != null)
            {
                Scene.AddColliderInternal(c);
            }
            return c;
        }

        /// <summary>
        /// Remove the collider from the entity.
        /// </summary>
        /// <param name="c"></param>
        public T RemoveCollider<T>(T c) where T : Collider
        {
            if (Colliders.Contains(c))
            {
                Colliders.Remove(c);
                c.Removed();
                c.Entity = null;

                if (Scene != null)
                {
                    Scene.RemoveColliderInternal(c);
                }
            }
            return c;
        }

        /// <summary>
        /// Remove all colliders from the entity.
        /// </summary>
        public void ClearColliders()
        {
            var colliders = new List<Collider>(Colliders);
            foreach (var c in colliders)
            {
                RemoveCollider(c);
            }
        }

        /// <summary>
        /// Remove all current colliders and set collider to a new one.
        /// </summary>
        /// <param name="c"></param>
        public T SetCollider<T>(T c) where T : Collider
        {
            for (int i = Colliders.Count - 1; i >= 0; i--)
            {
                RemoveCollider(Colliders[i]);
            }
            return AddCollider(c);
        }

        /// <summary>
        /// Adds colliders to the entity.
        /// </summary>
        /// <param name="colliders"></param>
        public List<Collider> AddColliders(params Collider[] colliders)
        {
            var r = new List<Collider>();
            foreach (Collider c in colliders)
            {
                r.Add(AddCollider(c));
            }
            return r;
        }

        /// <summary>
        /// Removes colliders from the entity.
        /// </summary>
        /// <param name="colliders"></param>
        public void RemoveColliders(params Collider[] colliders)
        {
            foreach (Collider c in colliders)
            {
                RemoveCollider(c);
            }
        }

        /// <summary>
        /// Checks for a collision using the first available Collider.
        /// </summary>
        /// <param name="x">The X position to check for a collision at.</param>
        /// <param name="y">The Y position to check for a collision at.</param>
        /// <param name="tags">The int tags to check for.</param>
        /// <returns></returns>
        public Collider Collide(float x, float y, params int[] tags)
        {
            return Collider.Collide(x, y, tags);
        }

        /// <summary>
        /// Checks for a collision using the first available Collider.
        /// </summary>
        /// <param name="x">The X position to check for a collision at.</param>
        /// <param name="y">The Y position to check for a collision at.</param>
        /// <param name="tags">The enum tags to check for.</param>
        /// <returns></returns>
        public Collider Collide(float x, float y, params Enum[] tags)
        {
            return Collider.Collide(x, y, tags);
        }

        /// <summary>
        /// Checks for a collision with the first available Collider.
        /// </summary>
        /// <param name="x">The X position to check for a collision at.</param>
        /// <param name="y">The Y position to check for a collision at.</param>
        /// <param name="tags">The int tags to check for.</param>
        /// <returns>A list of all colliders touched.</returns>
        public List<Collider> CollideList(float x, float y, params int[] tags)
        {
            return Collider.CollideList(x, y, tags);
        }

        /// <summary>
        /// Checks for a collision with the first available Collider.
        /// </summary>
        /// <param name="x">The X position to check for a collision at.</param>
        /// <param name="y">The Y position to check for a collision at.</param>
        /// <param name="tags">The enum tags to check for.</param>
        /// <returns>A list of all colliders touched.</returns>
        public List<Collider> CollideList(float x, float y, params Enum[] tags)
        {
            return Collider.CollideList(x, y, tags);
        }

        /// <summary>
        /// Checks for a collision with the first available Collider.
        /// </summary>
        /// <param name="x">The X position to check for a collision at.</param>
        /// <param name="y">The Y position to check for a collision at.</param>
        /// <param name="tags">The int tags to check for.</param>
        /// <returns>A list of all entities touched.</returns>
        public List<Entity> CollideEntities(float x, float y, params int[] tags)
        {
            return Collider.CollideEntities(x, y, tags);
        }

        /// <summary>
        /// Checks for a collision with the first available Collider.
        /// </summary>
        /// <param name="x">The X position to check for a collision at.</param>
        /// <param name="y">The Y position to check for a collision at.</param>
        /// <param name="tags">The enum tags to check for.</param>
        /// <returns>A list of all Entities touched.</returns>
        public List<Entity> CollideEntities(float x, float y, params Enum[] tags)
        {
            return Collider.CollideEntities(x, y, tags);
        }

        /// <summary>
        /// Checks for an overlap using the first available collider.
        /// </summary>
        /// <param name="x">The X position to check for a collision at.</param>
        /// <param name="y">The Y position to check for a collision at.</param>
        /// <param name="tags">The int tags to check for.</param>
        /// <returns>True if there is a collision.</returns>
        public bool Overlap(float x, float y, params int[] tags)
        {
            Overlapped = null;

            var result = Collider.Overlap(x, y, tags);
            if (result)
            {
                Overlapped = Collider.Collide(x, y, tags).Entity;
            }

            return result;
        }

        /// <summary>
        /// Checks for an overlap using the first available collider.
        /// </summary>
        /// <param name="x">The X position to check for a collision at.</param>
        /// <param name="y">The Y position to check for a collision at.</param>
        /// <param name="tags">The enum tags to check for.</param>
        /// <returns>True if there is a collision.</returns>
        public bool Overlap(float x, float y, params Enum[] tags)
        {
            return Overlap(x, y, Util.EnumToIntArray(tags));
        }

        /// <summary>
        /// Checks for an overlap using the first available collider.
        /// </summary>
        /// <param name="x">The X position to check for a collision at.</param>
        /// <param name="y">The Y position to check for a collision at.</param>
        /// <param name="e">The Entity to check for a collision with.</param>
        /// <returns>True if there is a collision.</returns>
        public bool Overlap(float x, float y, Entity e)
        {
            Overlapped = null;

            var result = Collider.Overlap(x, y, e);
            if (result)
            {
                Overlapped = Collider.Collide(x, y, e).Entity;
            }

            return result;
        }

        /// <summary>
        /// Called when the entity is added to a scene.  The reference to the Scene is available here.
        /// </summary>
        public virtual void Added()
        {

        }

        /// <summary>
        /// Called when the entity is removed from a scene.  The reference to Scene is now null.
        /// </summary>
        public virtual void Removed()
        {

        }

        /// <summary>
        /// Called when the Scene begins.
        /// </summary>
        public virtual void SceneBegin()
        {

        }

        /// <summary>
        /// Called when the Scene ends.
        /// </summary>
        public virtual void SceneEnd()
        {

        }

        /// <summary>
        /// Called when the Scene is paused.
        /// </summary>
        public virtual void ScenePause()
        {

        }

        /// <summary>
        /// Called when the Scene is resumed.
        /// </summary>
        public virtual void SceneResume()
        {

        }

        /// <summary>
        /// Called when the entity is paused by the Scene.
        /// </summary>
        public virtual void Paused()
        {

        }

        /// <summary>
        /// Called when the entity is resumed by the Scene.
        /// </summary>
        public virtual void Resumed()
        {

        }

        /// <summary>
        /// Tweens a set of numeric properties on an object.
        /// </summary>
        /// <param name="target">The object to tween.</param>
        /// <param name="values">The values to tween to, in an anonymous type ( new { prop1 = 100, prop2 = 0} ).</param>
        /// <param name="duration">Duration of the tween in seconds.</param>
        /// <param name="delay">Delay before the tween starts, in seconds.</param>
        /// <returns>The tween created, for setting properties on.</returns>
        public Glide Tween(object target, object values, float duration, float delay = 0)
        {
            return Tweener.Tween(target, values, duration, delay);
        }

        /// <summary>
        /// Called first during the update.  Happens before Update.
        /// </summary>
        public virtual void UpdateFirst()
        {

        }

        /// <summary>
        /// Called last during the update.  Happens after Update.
        /// </summary>
        public virtual void UpdateLast()
        {

        }

        /// <summary>
        /// Called during the update of the game.
        /// </summary>
        public virtual void Update()
        {

        }

        /// <summary>
        /// Called when the entity is rendering to the screen.
        /// </summary>
        public virtual void Render()
        {

        }

        /// <summary>
        /// Remove this entity from the Scene it's in.
        /// </summary>
        public void RemoveSelf()
        {
            if (Scene != null && !MarkedForRemoval)
            {
                Scene.Remove(this);
            }
        }

        #endregion

        #region Internal

        internal bool MarkedForRemoval = false;

        internal int
            oldLayer,
            oldOrder;

        internal void UpdateFirstInternal()
        {
            Game.UpdateCount++;

            updatedOnce = true;

            foreach (Component c in componentsToRemove)
            {
                Components.Remove(c);
            }
            componentsToRemove.Clear();

            foreach (Component c in componentsToAdd)
            {
                Components.Add(c);
            }
            componentsToAdd.Clear();

            foreach (Component c in Components)
            {
                c.UpdateFirst();
            }
            if (OnUpdateFirst != null)
            {
                OnUpdateFirst();
            }
            UpdateFirst();
        }

        internal void UpdateLastInternal()
        {
            foreach (Component c in componentsToRemove)
            {
                Components.Remove(c);
            }
            componentsToRemove.Clear();

            foreach (Component c in componentsToAdd)
            {
                Components.Add(c);
            }
            componentsToAdd.Clear();

            foreach (Component c in Components)
            {
                c.UpdateLast();
                c.Timer += Game.DeltaTime;
            }

            UpdateLast();
            if (OnUpdateLast != null)
            {
                OnUpdateLast();
            }

            foreach (Graphic g in Graphics)
            {
                g.Update();
            }

            Timer += Game.DeltaTime;
            if (LifeSpan > 0)
            {
                if (Timer >= LifeSpan)
                {
                    RemoveSelf();
                }
            }
        }

        internal void UpdateInternal()
        {
            foreach (Component c in componentsToRemove)
            {
                Components.Remove(c);
            }
            componentsToRemove.Clear();

            foreach (Component c in componentsToAdd)
            {
                Components.Add(c);
            }
            componentsToAdd.Clear();

            foreach (Component c in Components)
            {
                c.Update();
            }
            if (OnUpdate != null)
            {
                OnUpdate();
            }
            Tweener.Update(Game.DeltaTime);

            Update();
        }

        internal void RenderInternal()
        {
            if (!updatedOnce) return; //prevent rendering before update
            if (!Visible) return;
            if (Scene == null) return;

            if (Surface == null)
            {
                RenderEntity();
            }
            else
            {
                foreach (var surface in Surfaces)
                {
                    Surface temp = Draw.Target;

                    Draw.SetTarget(surface);

                    RenderEntity();

                    Draw.SetTarget(temp);
                }
            }
        }

        #endregion
    }
}
