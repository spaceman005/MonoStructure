using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStructure.GameStates
{
    public class StateManager
    {
        private static StateManager _instance;
        private ContentManager _content;
        private Stack<State> _screens = new Stack<State>();

        public static StateManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StateManager();
                }
                return _instance;
            }
        }

        public void SetContent(ContentManager content)
        {
            _content = content;
        }
        public void AddScreen(State screen)
        {
            try
            {
                // Add the screen to the stack
                _screens.Push(screen);
                // Initialize the screen
                _screens.Peek().Initialize();
                // Call the LoadContent on the screen
                if (_content != null)
                {
                    _screens.Peek().LoadContent(_content);
                }
            }
            catch (Exception ex){ }
        }

        // Removes the top screen from the stack
        public void RemoveScreen()
        {
            if (_screens.Count > 0)
            {
                try
                {
                    var screen = _screens.Peek();
                    _screens.Pop();
                }
                catch (Exception ex){ }
            }
        }
        public void ClearScreens()
        {
            while (_screens.Count > 0)
            {
                _screens.Pop();
            }
        }

        public void ChangeScreen(State screen)
        {
            try
            {
                ClearScreens();
                AddScreen(screen);
            }
            catch (Exception ex){ }
        }

        public void Update(GameTime gameTime)
        {
            try
            {
                if (_screens.Count > 0)
                {
                    _screens.Peek().Update(gameTime);
                }
            }
            catch (Exception ex) { }
        }

        // Renders the top screen.
        public void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                if (_screens.Count > 0)
                {
                    _screens.Peek().Draw(spriteBatch);
                }
            }
            catch (Exception ex){ }
        }

        public void UnloadContent()
        {
            foreach (State state in _screens)
            {
                state.UnloadContent();
            }
        }
    }

}
