import { Component, OnInit } from '@angular/core';
import { Treatment } from '../../models/treatment';

import { TreatmentService } from '../../services/treatment/treatment.service';

@Component({
	selector: 'ca-statutory', 
	templateUrl: './statutory.component.html'
})

export class StatutoryComponent implements OnInit {
	treatments: Treatment[]
	selectedTreatment: Treatment;
	
	constructor(private treatmentService: TreatmentService){

	}

	ngOnInit(): void {
		this.getTreatments();
	}

	getTreatments() {
		this.treatmentService.getTreatments().then(t=> {
		this.treatments = t;
		this.selectedTreatment = t[0];
		});
	}
}