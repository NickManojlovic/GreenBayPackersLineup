import { Injectable } from '@angular/core';
import { Http, Response, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/throw';

import { IPlayer } from './player';

@Injectable()
export class PlayerService {
    private url = "api/teams";

    constructor(private _http: Http) {
        this.url = this.url;
    }

    getByTeam(teamName:string): Observable<IPlayer[]> {
        return this._http.get(`${this.url}/${teamName}/players`)
            .map((response: Response) => <IPlayer[]>response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error);
    }
}
