            paddlerect = new Rectangle((int)paddlepos.X, (int)paddlepos.Y, paddle.Width, paddle.Height);
            ms = Mouse.GetState();
            paddlepos.X = ms.X;
        
            
            if (ballrect.Intersects(paddlerect))
            {
                bhpaddle();
            }
            ballpos += ballvel;
            if (ballrect.Y>= paddlerect.Y)
            {
                ballpos = new Vector2(400, 480);
                bhpaddle();
                ballpos += ballvel;
                l--;
            }
            
            base.Update(gameTime);
        }
