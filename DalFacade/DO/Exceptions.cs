namespace DO
{
    [Serializable]
    public class Dal_No_exist : Exception//הישות לא נמצאה 
    {
        public Dal_No_exist() : base() { }

        public Dal_No_exist(string message,string intrface) : base(message) { }

        
    }
    [Serializable]
    public class Dal_exist : Exception//הישות קימת כבר
    {
        public Dal_exist() : base() { }

        public Dal_exist(string message, string intrface) : base(message) { }


    }
    public class Dal_Successed : Exception//הישות קימת כבר
    {
        public Dal_Successed() : base() { }

        public Dal_Successed(string message, string intrface) : base(message) { }


    }

}

