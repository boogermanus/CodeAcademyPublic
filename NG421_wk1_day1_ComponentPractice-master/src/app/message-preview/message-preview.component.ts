import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-message-preview',
  templateUrl: './message-preview.component.html',
  styleUrls: ['./message-preview.component.css']
})
export class MessagePreviewComponent implements OnInit {

  @Input()
  public message: any;
  constructor() { }

  ngOnInit() {
  }

}
