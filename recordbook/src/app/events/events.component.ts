import { Component, OnInit } from '@angular/core';
import { EventService } from '../services/eventService';
import { EventModel } from '../model/eventModel';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {

  private events: EventModel[];
  

  constructor(private service: EventService) { }

  ngOnInit() {
    this.service.getAll().subscribe((data: EventModel[]) => this.events = data);
  }

}
