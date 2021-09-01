package io.workoutapi.workout;

import java.util.List;
import io.workoutapi.exercise.Exercise;

public class Workout {
	private String id;
	private int week, day;
	private List<Exercise> exercises;
	
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
	public List<Exercise> getExercises() {
		return exercises;
	}
	public void setExercises(List<Exercise> exercises) {
		this.exercises = exercises;
	}
}
