package io.workoutapi.exercise;

public class Exercise {
	private String id, name, reps;
	private double weight;
	
	public Exercise(String id, String name, String reps, double weight) {
		super();
		this.id = id;
		this.name = name;
		this.reps = reps;
		this.weight = weight;
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
	
	
}
