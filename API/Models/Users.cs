using MongoDB.Bson.Serialization.Attributes;



namespace EGDaySchedule.Models
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? _id { get; set; }
        public int userAutoId { get; set; }
        public string? identifier { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        //removed url from users and created a seperate table "UsersUrl"
        //public string? url { get; set; }
        public string? phone { get; set; }
        public string? location { get; set; }
        public string? timeZone { get; set; }
        public string? team { get; set; }
        public string? oldMailOtp { get; set; }
        //public int signInType { get; set; }
        public string? newMailOtp { get; set; }
        public string? accessToken { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? createdDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? updatedDate { get; set; }
        public int emailFlag { get; set; }
        public int deleteFlag { get; set; }
        public int isAdmin {  get; set; }
        public int passwordChangeFlag { get; set; } = 1;
        public int verifyMail { get; set; }

       
    }
    public class UserLoginResponse
    {
        public int userAutoID { get; set; }
        public int scheduleAutoId { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public List<UsersURL>? url { get; set; }
        public string? jwtToken { get; set; }
        public bool? isAuthorized { get; set; }
        public bool? verification { get; set; }
        public int isAdmin { get; set; }
    }
    public class SignInModel
    {
        public string name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public int signInType { get; set; }
    }

    public class APIResponseData
    {
        public string? status { get; set; } = "Failed";
        public string? errorMsg { get; set; } = "";
        public dynamic? data { get; set; } = null;    // Data should be List
        public int recordCount { get; set; } = 0;
        public DateTime? responseTime { get; set; } = DateTime.Now;
    }
}