import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServicesService } from '../services.service';
import { AuthService } from '../auth.service';
import { a } from '@angular/core/src/render3';

@Component({
  selector: 'app-add-service',
  templateUrl: './add-service.component.html',
  styleUrls: ['./add-service.component.css']
})

export class AddServiceComponent implements OnInit {

  serviceData:any={}
  imageData:File=null;
  image;
  constructor(private _router : Router, private services : ServicesService, private _auth: AuthService) { }

  ngOnInit() {
  }

  showError(error: string) {
    document.getElementById("error").innerHTML = error;
  }

  onImageSet(event){
    this.imageData=event.target.files[0];
  }
  _handleReaderLoaded(readerEvt) {
    var binaryString = readerEvt.target.result;
           this.image= btoa(binaryString);
           console.log(btoa(binaryString));
   }
  addNewService () {

    var file:File = this.imageData;
  var myReader:FileReader = new FileReader();

  myReader.onloadend = (e) => {
    this.serviceData.Image = myReader.result;
    this.services.addService(this.serviceData)
    .subscribe(
      res => {
        this._router.navigate(['/services'])
      },
      err => {this.showError(err.error);
        document.getElementById('serviceDesc').focus();}
        ) 
      }
      myReader.readAsDataURL(file);
  }

}
interface FileReaderEventTarget extends EventTarget {
  result:string
}

interface FileReaderEvent extends Event {
  target: FileReaderEventTarget;
  getMessage():string;
}
