        private class SingleClickLabel : Label
        {
        	protected override CreateParams CreateParams
        	{
        		get
        		{
        			new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
        
        			CreateParams cp = base.CreateParams;
        			cp.ClassStyle &= ~0x0008;
        			cp.ClassName = null;
        
        			return cp;
        		}
        	}
        }
