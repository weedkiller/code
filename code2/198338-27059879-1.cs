        /// <summary>
        /// (In|De)creases a height of the «control» and the window «form», and moves accordingly
        /// down or up elements in the «move_list». To decrease size pass a negative argument
        /// to «the_sz».
        /// Usually used to collapse (or expand) elements of a form, and to move controls of the
        /// «move_list» down to fill the appeared gap.
        /// </summary>
        /// <param name="control">control to collapse/expand</param>
        /// <param name="form">form to get resized accordingly after the size of a control
        /// changed (pass «null» if you don't want to)</param>
        /// <param name="move_list">A list of controls that should also be moved up or down to
        /// «the_sz» size (e.g. to fill a gap after the «control» collapsed)</param>
        /// <param name="the_sz">size to change the control, form, and the «move_list»</param>
        public static void ToggleControlY(Control control, Form form, List<Control> move_list, int the_sz)
        {
            //→ Change sz of ctrl
            control.Height += the_sz;
            //→ Change sz of Wind
            if (form != null)
                form.Height += the_sz;
            //*** We leaved a gap(or intersected with another controls) now!
            //→ So, move up/down a list of a controls
            foreach (Control ctrl in move_list)
            {
                Point loc = ctrl.Location;
                loc.Y += the_sz;
                ctrl.Location = loc;
            }
        }
