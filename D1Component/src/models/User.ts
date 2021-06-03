export class User {
    location: string;
    name: string;
    profileImage: string;
    reviews: number;

    constructor(name: string, location: string, img: string, reviews: number) {
        this.name = name;
        this.location = location;
        this.profileImage = img;
        this.reviews = reviews;
    }
}
