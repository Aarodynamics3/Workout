package io.workoutapi.workout;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "workouts")
public class Workout {
	@Id
	private String id;
	private int week, day;
	
	public Workout() {
		
	}
	
	public Workout(String id, int week, int day) {
		super();
		this.id = id;
		this.week = week;
		this.day = day;
	}
	
	public String getId() {
		return id;
	}
	public void setId(String id) {
		this.id = id;
	}
	public int getWeek() {
		return week;
	}
	public void setWeek(int week) {
		this.week = week;
	}
	public int getDay() {
		return day;
	}
	public void setDay(int day) {
		this.day = day;
	}
}
