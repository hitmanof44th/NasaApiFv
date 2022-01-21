namespace ApiNasaRovers.Data
{
    public static class returnstatus
    {
        // just a class for quick returns so return data can be uniform
        public static string Failed()
        {
            return "{'status':'failed'}";
        }


        public static string Failed(string data)
        {
            return "{'status':'failed','data':"+data+"}";
        }



        public static string Success(string data)
        {
            return "{'status':'success','data':" + data + "}";
        }



        public static string Success()
        {
            return "{'status':'success'}";
        }


    }
}
