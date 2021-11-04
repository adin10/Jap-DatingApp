import { Photo } from "./photo.model";

export interface Member{
                appUserID:number,
                 firstName:string,
                 lastName:string,
                 username:string,
                photoUrl:string,
                 age:number,
                createdDate:Date,
                 gender:string,
                city:string,
                country:string,
                photos:Photo[]        
        
}
// public int AppUserID { get; set; }
// public string FirstName { get; set; }
// public string LastName { get; set; }
// public string Username { get; set; }
// public string PhotoUrl { get; set; }
// public int Age { get; set; }
// public DateTime CreatedDate { get; set; }
// public string Gender { get; set; }
// public string City { get; set; }
// public string Country { get; set; }

// public ICollection<PhotoDto> Photos { get; set; }