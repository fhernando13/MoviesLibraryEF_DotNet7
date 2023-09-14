import { Validators, ValidatorFn, AbstractControl, ValidationErrors } from "@angular/forms";

export class CustomValidators extends Validators {
    static onlyNumbers(control: AbstractControl): ValidationErrors | null {
      return /^\d+$/.test(control.value) ? null : { onlyNumbers: true };
    }

    static mustBeEquals(nameFirstControl: string, nameSecondControl: string): ValidatorFn{
        return (group: AbstractControl): ValidationErrors | null => {
            const firstControl = group.getError(nameFirstControl);
            const secondControl = group.getError(nameSecondControl);
            return firstControl?.value === secondControl?.value ? null : {mustbeEquals: true}
        }
    }
}