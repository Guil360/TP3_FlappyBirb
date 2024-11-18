import { Component, OnInit } from '@angular/core';
import { Score } from '../models/score';
import { MaterialModule } from '../material.module';
import { CommonModule } from '@angular/common';
import { Round00Pipe } from '../pipes/round-00.pipe';
import { ScoreService } from '../services/score.service';

@Component({
  selector: 'app-score',
  standalone: true,
  imports: [MaterialModule, CommonModule, Round00Pipe],
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.css']
})
export class ScoreComponent implements OnInit {

  myScores: Score[] = [];
  publicScores: Score[] = [];
  userIsConnected: boolean = false;

  constructor(private scoreService: ScoreService) { }

  async ngOnInit() {
    console.log("ngOnInit called");
  
    const token = localStorage.getItem("token") || sessionStorage.getItem("token");
    console.log("Token:", token);
  
    this.userIsConnected = !!token;
    console.log("User is connected:", this.userIsConnected);
  
    this.getPublicScores();
  
    if (this.userIsConnected) {
      console.log("Fetching My Scores...");
      this.getMyScores(token!);
    }
  }

  getUserIdFromToken(token: string): string | null {
    try {
      const payload = JSON.parse(atob(token.split('.')[1])); // Decode JWT payload
      console.log("Decoded Token Payload:", payload); // Debug log
      return payload.userId || null; // Use `userId` if available
    } catch (error) {
      console.error("Failed to parse token:", error);
      return null;
    }
  }
  

  getUsernameFromToken(token: string): string | null {
    try {
      const payload = JSON.parse(atob(token.split('.')[1])); // Decode JWT payload
      console.log("Decoded Token Payload:", payload); // Debug log
      return payload.username || null; // Use `username` if available
    } catch (error) {
      console.error("Failed to parse token:", error);
      return null;
    }
  }
  
  
  
  

  async changeScoreVisibility(score: Score) {
    if (!this.userIsConnected) {
      alert("Vous devez être connecté pour effectuer cette action");
      return;
    }

    score.isPublic = !score.isPublic;

    const token = localStorage.getItem("token") || sessionStorage.getItem("token");

    if (token) {
      this.scoreService.toggleVisibility(score.id, token, score.isPublic).subscribe({
        next: () => {
          console.log("Score visibility updated");
        },
        error: (error) => {
          console.error(error);
        }
      });
      this.getMyScores(token);
    } else {
      console.error("No token found");
    }
  }

  getMyScores(token: string) {
    const userId = token ? this.getUserIdFromToken(token) : null; // Get userId from the token if it exists
  
    this.scoreService.getMyScores(token).subscribe({
      next: (response: any) => {
        console.log("Raw My Scores Response:", response);
  
        this.myScores = response
          
          .map((score: any) => {
            const date = score.date ? this.parseDate(score.date) : 'N/A';
            return {
              username: score.username || 'Unknown',
              scoreValue: score.amount || 0,
              timeInSeconds: score.timeInSeconds || 0,
              date: date,
              isPublic: score.isPublic || false,
            };
          });
          console.log("Filtered My Scores:", this.myScores);
      },
      error: (error: any) => {
        console.error("Error fetching My Scores:", error);
      },
    });
  }
  
  
  
  
  
  
  getPublicScores() {
    this.scoreService.getPublicScores().subscribe({
      next: (response) => {
        this.publicScores = response.map((score: any) => {
          const date = score.date ? this.parseDate(score.date) : 'N/A';
          return {
            pseudo: score.pseudo || 'Unknown',
            scoreValue: score.scoreValue || 0,
            timeInSeconds: score.scoreInSeconds || 0,
            date: date,
          };
        });
      },
      error: (error) => {
        console.error(error);
      }
    });
  }
  
  private parseDate(date: string): string {
    return new Date(date).toLocaleDateString();
  }
  
}
