    Partial Public Class MainForm
        Private loadingComplete As Boolean = False
        Public Sub New()
            InitializeComponent()
            RestoreWindowLocation()
        End Sub
        Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        	loadingComplete = True
        End Sub
        Private Sub MainForm_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
             TrackWindowLocation()
         End Sub
         Private Sub MainForm_Move(sender As System.Object, e As System.EventArgs) Handles MyBase.Move
        
	         TrackWindowLocation()
         End Sub
        Private Sub MainForm_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
	        SaveWindowLocation()
         End Sub
        Private Sub RestoreWindowLocation()
            If IsRectangleVisible(My.Settings.WindowBounds) Then
                Me.StartPosition = FormStartPosition.Manual
                Me.DesktopBounds = My.Settings.WindowBounds
            End If
            If Not My.Settings.WindowState = FormWindowState.Minimized Then
                Me.WindowState = My.Settings.WindowState
            End If
        End Sub
        Private Sub TrackWindowLocation()
            If loadingComplete Then
                If Me.WindowState = FormWindowState.Normal Then
                    My.Settings.WindowBounds = Me.DesktopBounds
                    My.Settings.WindowState = Me.WindowState
                End If
            End If
        End Sub
        Private Sub SaveWindowLocation()
            If Not Me.WindowState = FormWindowState.Minimized Then
                My.Settings.WindowState = Me.WindowState
            End If
            
            If Me.WindowState = FormWindowState.Normal Then
                My.Settings.WindowBounds = Me.DesktopBounds
            End If
            My.Settings.Save()
        End Sub
        Private Function IsRectangleVisible(Rectangle As Rectangle) As Boolean
            For Each screen As Screen In screen.AllScreens
                Dim r As Rectangle = Rectangle.Intersect(Rectangle, screen.WorkingArea)
                If Not r.IsEmpty Then
                    If r.Width > 50 And r.Height > 50 Then Return True
                End If
            Next
            Return False
        End Function
    
    End Class
