import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input() userFromHomeComponent: any;
  @Output() cancelRegister = new EventEmitter();

  model: any = {};
  
  constructor(private accountService: AccountService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  register() {
    this.accountService.register(this.model).subscribe(respose => {
      console.log(respose);
      this.cancel();
    }, error => {
      this.toastr.error(error.console.error);
      console.log(error);

    });
    
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
