import { TestBed } from '@angular/core/testing';

import { JusticeLeagueService } from './justice-league.service';

describe('JusticeLeagueService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: JusticeLeagueService = TestBed.get(JusticeLeagueService);
    expect(service).toBeTruthy();
  });
});
