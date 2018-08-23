import { Component, Inject, Input, Output, EventEmitter } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-borrower-portal",
  templateUrl: "./borrower-portal.component.html",
  styleUrls: ["./borrower-portal.component.css"]
})
export class BorrowerPortalComponent {
  public borrower: Borrower;
  withdraw: number;

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    http.get<Borrower>(baseUrl + "api/Borrower").subscribe(
      result => {
        this.borrower = result;
      },
      error => {
        console.error(error);
        alert(error.error.DeveloperMessage);
      }
    );
  }

  @Input() inFormMode: boolean;
  @Output() formEnabled = new EventEmitter<boolean>();

  refreshData($borrower: Borrower) {
    this.borrower = $borrower;
    this.hideWithdrawForm();
  }

  showWithdrawForm() {
    this.withdraw = 0;
    this.enableForm(true);
  }

  hideWithdrawForm() {
    this.enableForm(false);
  }

  enableForm(enable: boolean) {
    this.inFormMode = enable;
    this.formEnabled.emit(enable);
  }
}

export class Borrower {
  id: string;
  firstName: string;
  lastName: string;
  creditLimit: number = 0;
  balance: number = 0;
  availableFunds: number = 0;
}
