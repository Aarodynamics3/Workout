package io.workoutapi.exercise;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;
import io.workoutapi.workout.Workout;

@Entity
@Table(name = "exercises")
public class Exercise {
	@Id
	private String id;
	private String name, reps;
	private double weight;
	
	@ManyToOne
	@JoinColumn(name = "workout_id")
	private Workout workout;
	
	public Exercise(String id, String name, String reps, double weight, Workout workout) {
		super();
		this.id = id;
		this.name = name;
		this.reps = reps;
		this.weight = weight;
		this.workout = workout;
	}
	
	public String getId() {
		return id;
	}
	public void setId(String id) {
		this.id = id;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getReps() {
		return reps;
	}
	public void setReps(String reps) {
		this.reps = reps;
	}
	public double getWeight() {
		return weight;
	}
	public void setWeight(double weight) {
		this.weight = weight;
	}
	public Workout getWorkout() {
		return workout;
	}
	public void setWorkout(Workout workout) {
		this.workout = workout;
	}
	
}
