import { Category } from "./category.model";
import { Comment } from "./comment.model";
import { Rating } from "./rating.model";
import { User } from "./user.model";

export class Service {
    Category: Category;
    Comments: Comment;
    DateOfAddition: Date;
    Descryption: String;
    ID: Number;
    Rating: Rating;
    Status: Number;
    User: User;
  }