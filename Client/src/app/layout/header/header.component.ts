import { Component, inject } from '@angular/core';
import {MatBadge} from '@angular/material/badge';
import {MatButton} from '@angular/material/button';
import { MatProgressBar } from '@angular/material/progress-bar';
import {MatIcon} from '@angular/material/icon';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { BusyService } from '../../core/services/busy.service';
@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
      MatBadge,
      MatButton,
      MatIcon,
      RouterLink,
      RouterLinkActive,
      MatProgressBar
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
    busyService=inject(BusyService);
}
