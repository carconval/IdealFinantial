import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
  selector: "app-nav-bar",
  templateUrl: "./nav-bar.component.html",
  styleUrls: ["./nav-bar.component.css"]
})
export class NavBarComponent {
  @Input() inFormMode: boolean;
  @Output() formCanceled = new EventEmitter();
}
