import { Component, OnInit } from '@angular/core';
import { Game } from './gameLogic/game';
import { MaterialModule } from '../material.module';
import { CommonModule } from '@angular/common';

const domaineServeur = "https://localhost:7059/";
@Component({
  selector: 'app-play',
  standalone: true,
  imports: [MaterialModule, CommonModule],
  templateUrl: './play.component.html',
  styleUrl: './play.component.css'
})
export class PlayComponent implements OnInit{

  game : Game | null = null;
  scoreSent : boolean = false;
  
  constructor(){}

  ngOnDestroy(): void {
    location.reload();
  }

  ngOnInit() {
    this.game = new Game();
  }

  replay(){
    if(this.game == null) return;
    this.game.prepareGame();
    this.scoreSent = false;
  }

  async sendScore() {
    if (this.scoreSent) return;

    this.scoreSent = true;

    const score = parseInt(sessionStorage.getItem("score") || "0", 10);
    const timeInSeconds = parseInt(sessionStorage.getItem("time") || "0", 10);

    if (isNaN(score) || isNaN(timeInSeconds)) {
        console.error("Invalid score or time data.");
        return;
    }

    const token = localStorage.getItem("token") || sessionStorage.getItem("token");
    if (token == null) return;

    try {
        const response = await fetch(`${domaineServeur}api/Scores/PostScore`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
            },
            body: JSON.stringify({ 
                score: score,
                timeInSeconds: timeInSeconds,
                Date: new Date().toISOString(),
                visible: true
            })
        });

        if (!response.ok) {
            const error = await response.json();
            console.error('Error from server:', error);
            throw new Error('Network response was not ok');
        }

        const data = await response.json();
        console.log('Score successfully sent:', data);
        this.scoreSent = true;
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
  }
}
