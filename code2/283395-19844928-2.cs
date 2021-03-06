        public ActionResult GetAttachment(long id)
        {
            FileAttachment attachment;
            using (var db = new TheContext())
            {
                attachment = db.FileAttachments.FirstOrDefault(x => x.Id == id);
            }
            return File(attachment.FileName, "application/force-download", Path.GetFileName(attachment.FileName));
        }
