import { Injectable } from "@angular/core";

@Injectable()
export class Helpers {
    constructor() {}

    public localStorageItem(id: string): string {
        return localStorage.getItem(id)
    }
}