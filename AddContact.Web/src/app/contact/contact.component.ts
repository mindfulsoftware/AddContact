import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';
import { filter, map, switchMap, takeUntil } from 'rxjs/operators';
import { ContactService } from './contact.service';
import { Contact } from './contact';
import { routeParts } from '../constants';

@Component({
    styleUrls: ['./contact.component.scss'],
    templateUrl: './contact.component.html'
})
export class ContactComponent implements OnDestroy, OnInit {
    private readonly unsubscribe = new Subject<never>();

    constructor(private contactService: ContactService, private route: ActivatedRoute){        
    }

    ngOnInit(): void{
        this.route.params.pipe(
            map(p => p[routeParts.idParam]),
            map(id => Number(id)),
            filter(id => !isNaN(id)),
            switchMap(id => this.contactService.getById(id)),
            takeUntil(this.unsubscribe)
        ).subscribe(c => this.onContactLoaded(c));
    }

    ngOnDestroy(): void{
        this.unsubscribe.next();
    }

    private onContactLoaded(contact: Contact): void{  
    }
}