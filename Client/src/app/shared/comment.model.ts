import { User } from "./user.model";

export class Comment {
    public ID: number;
    public Content: String;
    public User: User;
    public DateOfAddition: Date;
}