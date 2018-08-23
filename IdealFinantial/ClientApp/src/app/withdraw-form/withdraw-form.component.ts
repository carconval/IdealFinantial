import { NgModule, Component, Inject, Input, Output, OnInit, EventEmitter } from "@angular/core";
import { ReactiveFormsModule, FormGroup, FormControl, Validators, ValidatorFn } from '@angular/forms';
import { HttpClient } from "@angular/common/http";
import { Borrower } from "../borrower-portal/borrower-portal.component";

@Component({
  selector: "app-withdraw-form",
  templateUrl: "./withdraw-form.component.html",
  styleUrls: ["./withdraw-form.component.css"]
})
export class WithdrawFormComponent implements OnInit {
  @Input() userId: string;
  public myForm: FormGroup;
  public amountCtrl: FormControl;
  public errorMessage: string;
  private httpClient: HttpClient;
  private url: string;

  @Output() withdrawMade = new EventEmitter<Borrower>();
  @Input() set amount(amt: number) {
    if (this.amountCtrl) {
      this.amountCtrl.reset(amt);
    }
  }

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.httpClient = http;
    this.url = baseUrl + "api/Borrower";
  }

  ngOnInit() {
    this.amountCtrl = new FormControl(0, [
      Validators.required,
      this.validateAmount()
    ]);
    this.myForm = new FormGroup({
      amount: this.amountCtrl
    });
  }

  makeWithdraw() {
    if (!this.myForm.valid) {
      return;
    }
    var amount = this.myForm.controls.amount.value;
    var withdraw = { "userId": this.userId, "amount": amount };
    this.httpClient.post<Borrower>(this.url, withdraw).subscribe(r => {
      this.withdrawMade.emit(r);
    },
    error => {
      console.error(error);
      alert(error.error.DeveloperMessage);
    });
  }

  validateAmount(): ValidatorFn {
    return (control: FormControl): { [key: string]: any } | null => {
      const valid = parseFloat(control.value) > 0;
      return valid ? null : { 'amount': { value: control.value } };
    };
  }
}
