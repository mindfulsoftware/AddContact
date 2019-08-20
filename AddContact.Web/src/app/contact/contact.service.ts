import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contact } from './Contact';
import { Injectable } from '@angular/core';

@Injectable()
export class ContactService {
    private readonly baseUrl = 'http://localhost:5000/api/contacts';
    private readonly headers = new HttpHeaders({
        'Content-Type': 'application/json'
    });

    constructor(private httpClient: HttpClient){        
    }

    getById(id: number): Observable<Contact>{        
        const url = `${this.baseUrl}/${id}`;
        return this.httpClient.get<Contact>(url, { headers: this.headers } )
    }
}