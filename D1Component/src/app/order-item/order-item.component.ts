import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-order-item',
  templateUrl: './order-item.component.html',
  styleUrls: ['./order-item.component.css']
})
export class OrderItemComponent implements OnInit {

  @Input()order: any = null;
  constructor() { }

  ngOnInit(): void {
  }
  public getDeliveredText(order: any) {
    return order.delivered ? 'Delivered' : 'Not Delivered';
  }

  public getTextColor(order: any) {
    return order.delivered ? 'green' : 'red';
  }
}
