import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Animal } from 'src/models/animal';
import {lastValueFrom } from 'rxjs';

// ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄
// Changez le domaine avec le bon port !!!
// ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
const domain = "https://localhost:7087/";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  // Inputs
  id ?: number;
  type : string = "";
  name : string = "";

  animals : Animal[] = [];
  animal ?: Animal;

  constructor(public http : HttpClient){}

  // Récupère tous les animaux dans la base de données
  async getAnimals() : Promise<void>{
    let x = await lastValueFrom(this.http.get<Animal[]>(domain + "api/Animals/GetAnimal"));
    console.log(x);
    this.animals = x;
  }

  // Ajoute un animal dans la base de données
  async postAnimal() : Promise<void>{
    let a = new Animal(0, this.type, this.name);
    let x = await lastValueFrom(this.http.post<Animal>(domain + "api/Animals/PostAnimal", a));
    console.log(x);
  }

  // Récupère un animal en particulier dans la base de données
  async getAnimal() : Promise<void>{
    if(this.id != undefined){
      let x = await lastValueFrom(this.http.get<Animal>(domain + "api/Animals/GetAnimal/" + this.id));
      this.animal = x;
    }
  }

  // Modifie (ou crée) un animal en particulier dans la base de données
  async putAnimal() : Promise<void>{
    if(this.id != undefined){
      let a = new Animal(this.id, this.type, this.name);
      let x = await lastValueFrom(this.http.put<Animal>(domain + "api/Animals/PutAnimal/" + this.id, a));
      console.log(x);
    }
  }

  // Supprime un animal en particulier dans la base de données
  async deleteAnimal() : Promise<void>{
    if(this.id != undefined){
      let x = await lastValueFrom(this.http.post<Animal>(domain + "api/destroy/" + this.id, null));
      console.log(x);
    }
  }

  async deleteAll() : Promise<void>{
    let x = await lastValueFrom(this.http.delete<any>(domain + "api/destroy"));
    console.log(x);
  }

}
