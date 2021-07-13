import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';

@Component({
  selector: 'app-reactive',
  templateUrl: './reactive.component.html',
  styleUrls: ['./reactive.component.css']
})
export class ReactiveComponent implements OnInit {

  form: FormGroup;
  name: FormControl = new FormControl('', Validators.required);
  email: FormControl = new FormControl('', Validators.compose([Validators.required, Validators.email]));
  password: FormControl = new FormControl('', Validators.compose([Validators.required, Validators.minLength(6)]));
  confirmPassword: FormControl = new FormControl('', Validators.compose([Validators.required, Validators.minLength(6)]));

  constructor(private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      name: this.name,
      email: this.email,
      password: this.password,
      confirmPassword: this.confirmPassword
    },
    {
      validators: this.mustMatch
    });
  }

  ngOnInit(): void {
  }

  submit(): void {
    console.log(this.form.value);
  }

  controlIsRequired(control: FormControl): boolean {
    return !control.valid && control.touched;
  }

  getControlErrorMessage(controlName: string, control: FormControl): string {

    if (control.errors.required) {
      return this.getErrorMessage(controlName, 'is required');
    }

    if (control.errors.email) {
      return this.getErrorMessage(controlName, 'must be a valid email address');
    }

    if (control.errors.minlength) {
      return this.getErrorMessage(controlName, 'must be greater than 6 characters');
    }

    if (control.errors.mustMatch) {
      return 'passwords do not match';
    }

    return 'unknown error';
  }

  private getErrorMessage(controlName: string, message: string): string {
    return `${controlName} ${message}`;
  }

  private mustMatch(form: FormGroup): void {

    if (form === undefined || form === null) {
      return null;
    }

    const control = form.get('password');
    const otherControl = form.get('confirmPassword');

    if (!control || !otherControl) {
      return null;
    }

    if (!!otherControl.errors && !otherControl.errors.mustMatch) {
      return null;
    }

    if (control.value !== otherControl.value) {
      otherControl.setErrors({mustMatch: true});
    } else {
      otherControl.setErrors(null);
    }
  }
}
