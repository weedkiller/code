    public class Postcommit
    {
        public string software_image_build { get; set; }
        public int TestStatus { get; set; }
    }
    ...
    PCS[i++].TestStatus = rdr.GetInt16(1);
