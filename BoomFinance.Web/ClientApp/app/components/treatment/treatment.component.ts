import { Component, Input } from '@angular/core';
import { Treatment } from '../../models/treatment';

@Component({
	selector: 'ca-treatment',
	templateUrl: 'treatment.component.html',
	styleUrls: ['./treatment.component.css']
})

export class TreatmentComponent  {
	@Input() treatments: Treatment[]; 
	@Input() selectedTreatment: Treatment;

	constructor(){
	if(this.treatments && this.treatments.length > 0){
		this.selectedTreatment = this.treatments[0];
		}
	}

	onSelect(treatment: Treatment) {
		this.selectedTreatment = treatment;
	}
	
}