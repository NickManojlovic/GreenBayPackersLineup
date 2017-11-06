import { Component, OnInit, AfterViewInit } from '@angular/core';
import { PlayerService } from './player.service';
import { IPlayer } from './player';
import { WOW } from 'wowjs/dist/wow.min';

@Component({
    selector: 'players',
    templateUrl: './player.component.html',
    styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit, AfterViewInit {
    error: boolean = false;
    search: string = "";
    players: IPlayer[] = null;

    constructor(private playerService: PlayerService) {
    }

    ngAfterViewInit(): void {
        new WOW().init();        
    }

    //get all players for team gb = green bay packers
    ngOnInit(): void {
        this.playerService.getByTeam("gb")
            .subscribe((items: IPlayer[]) => {
                    this.players = items;
                    //new WOW().sync();
                },
                error => {
                    console.log(error);
                    this.error = true;
                });
    }

    //clear search property
    clearSearch(): void {
        this.search = "";
    }
}