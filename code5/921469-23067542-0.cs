     Void GetCameraPhotos()
          {
            var imageList = new ObviousCollection<Images>();
            using (var library = new MediaLibrary())
            {
                
                PictureAlbumCollection allAlbums = library.RootPictureAlbum.Albums;
                PictureAlbum cameraRoll = allAlbums.Where(album => album.Name == "Camera Roll").FirstOrDefault();
                var CameraRollPictures = cameraRoll.Pictures
    
            }
          }
