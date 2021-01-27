import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/_models/User';

@Component({
  selector: 'app-merber-card',
  templateUrl: './merber-card.component.html',
  styleUrls: ['./merber-card.component.css']
})
export class MerberCardComponent implements OnInit {
  @Input() user: User;
  constructor() { }

  ngOnInit(): void {
  }

}
