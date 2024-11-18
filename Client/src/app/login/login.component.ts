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

  // Login method
  async login() {
    let loginDTO = new LoginDTO(this.loginUsername, this.loginPassword);

    try {
      // Send login request
      let response = await lastValueFrom(this.log.login(loginDTO));
      // Store token and user information in localStorage
      localStorage.setItem('token', response.token);
      localStorage.setItem('username', response.username);
      localStorage.setItem('userId', response.userId); // Store userId
      // Navigate to the game page
      this.route.navigate(['/play']);
    } catch (error) {
      console.error(error);
      alert('Erreur de connexion.');
    }
  }

  // Register method
  async register() {
    // Check if passwords match
    if (this.registerPassword !== this.registerPasswordConfirm) {
      alert('Les mots de passe ne correspondent pas');
      return;
    }

    // Create registration DTO object
    let registerDTO = {
      username: this.registerUsername,
      email: this.registerEmail,
      password: this.registerPassword,
      confirmPassword: this.registerPasswordConfirm
    };

    try {
      // Send registration request
      let response = await lastValueFrom(this.log.register(registerDTO));
      // Store token and user information in localStorage
      localStorage.setItem('token', response.token);
      localStorage.setItem('username', response.username);
      localStorage.setItem('userId', response.userId); // Store userId
      alert('Inscription réussie !');
      // Navigate to the game page
      this.route.navigate(['/play']);
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
