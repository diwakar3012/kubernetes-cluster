using MongoDB.Bson.Serialization.Attributes;

namespace EGDaySchedule.Models
{

    public class UsersURL
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? _id { get; set; }
        public int? userAutoId { get; set; }
        public int urlAutoId { get; set; }
        public string? name { get; set; }
        public string? url { get; set; }
        //public string? avatar { get; set; } = "https://cdn.dayschedule.com/icon/avatar.png";
        public string? avatar { get; set; } = "https://icon-library.com/images/avatar-icon-images/avatar-icon-images-4.jpg";
        public int RegURL { get; set; } = 0;
        public DateTime? createdDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? updatedDate { get; set; }
        public int? deleteFlag { get; set; } = 0;
    } 
}
