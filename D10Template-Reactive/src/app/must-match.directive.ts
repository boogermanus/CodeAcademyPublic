import { Directive, Input } from '@angular/core';
import { FormGroup, NG_VALIDATORS, ValidationErrors, Validator } from '@angular/forms';

@Directive({
  selector: '[appMustMatch]',
  providers: [{provide: NG_VALIDATORS, useExisting: MustMatchDirective, multi: true}]
})
export class MustMatchDirective implements Validator {

  // tslint:disable-next-line: no-input-rename
  @Input('appMustMatch')mustMatch: string[] = [];

  constructor() { }

  private static MustMatch(controlName: string, otherControlName: string) {
    return (formGroup: FormGroup) => {
      if (formGroup === undefined || formGroup === null) {
        return null;
      }
      const control = formGroup.controls[controlName];
      const otherControl = formGroup.controls[otherControlName];

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
    };
  }

  validate(formGroup: FormGroup): ValidationErrors {
    return MustMatchDirective.MustMatch(this.mustMatch[0], this.mustMatch[1])(formGroup);
  }

}
