import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MaterialModule } from '../material.module';
import { FormsModule } from '@angular/forms';
import { LoginService } from '../services/login.service';
import { lastValueFrom } from 'rxjs';
import { LoginDTO } from '../models/dto';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MaterialModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  hide = true;

  registerUsername : string = "";
  registerEmail : string = "";
  registerPassword : string = "";
  registerPasswordConfirm : string = "";

  loginUsername : string = "";
  loginPassword : string = "";

  constructor(public route : Router, private log: LoginService) { }

  ngOnInit() {
  }

  async login(){


    let loginDTO = new LoginDTO(this.loginUsername, this.loginPassword);
    try {
      let response = await lastValueFrom(this.log.login(loginDTO));
      localStorage.setItem("token", response.token);
      localStorage.setItem("username", response.username);
    } catch (error) {
      console.error(error);
    }
    //Sinon, on redirige vers la page de jeu
    this.route.navigate(["/play"]);
  }

  async register(){
    //On vérifie que les deux mots de passe sont identiques
    if(this.registerPassword != this.registerPasswordConfirm){
      alert("Les mots de passe ne correspondent pas");
      return;
    }
    //On crée un objet RegisterDTO
    let registerDTO = {
      username: this.registerUsername,
      email: this.registerPassword,
      password: this.registerPassword,
      passwordConfirm: this.registerPasswordConfirm

    };

    //La requete maintenant
    try {
      let response = await lastValueFrom(this.log.register(registerDTO));
      localStorage.setItem("token", response.token);
      localStorage.setItem("username", response.username);
    } catch (error) {
      console.error(error);
    }

  }
  
}
