package io.workoutapi.exercise;

import java.util.List;

import org.springframework.data.repository.CrudRepository;

public interface ExerciseRepository extends CrudRepository<Exercise, String> {
	public List<Exercise> findByWorkoutId(String workoutId);
}
