import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavBarComponent } from "./nav-bar/nav-bar.component";
import { BorrowerPortalComponent } from "./borrower-portal/borrower-portal.component";
import { WithdrawFormComponent } from "./withdraw-form/withdraw-form.component";

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    BorrowerPortalComponent,
    WithdrawFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "", component: BorrowerPortalComponent },
      { path: "withdraw-form", component: WithdrawFormComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
