import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class DobavljacAddEndpoint implements  MyBaseEndpoint<DobavljacAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: DobavljacAddRequest): Observable<void> {
    let url=Config.adresa + `Dobavljac-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface DobavljacAddRequest {
  naziv: string
}

