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

  ngOnInit() {}

  async login() {
    let loginDTO = new LoginDTO(this.loginUsername, this.loginPassword);

    try {
      let response = await lastValueFrom(this.log.login(loginDTO));
      localStorage.setItem('token', response.token);
      localStorage.setItem('username', response.username);
      localStorage.setItem('userId', response.userId);
      this.route.navigate(['/play']);
    } catch (error) {
      console.error(error);
      alert('Erreur de connexion.');
    }
  }

  async register() {
    if (this.registerPassword !== this.registerPasswordConfirm) {
      alert('Les mots de passe ne correspondent pas');
      return;
    }

    let registerDTO = {
      username: this.registerUsername,
      email: this.registerEmail,
      password: this.registerPassword,
      confirmPassword: this.registerPasswordConfirm
    };

    try {
      await lastValueFrom(this.log.register(registerDTO));
      alert('Inscription réussie !');
    } catch (error: any) {
      if (error.error?.errors) {
        let errors = Object.values(error.error.errors).flat();
        alert('Erreurs : \n' + errors.join('\n'));
      } else {
        console.error(error);
        alert("Erreur lors de l'inscription.");
      }
    }
  }
}
