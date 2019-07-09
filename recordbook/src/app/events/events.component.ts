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
    this.events = this.service.getAll();
    console.log(this.events);
  }

}
