package io.workoutapi.exercise;

import org.springframework.data.repository.CrudRepository;

public interface ExerciseRepository extends CrudRepository<Exercise, String> {
	
}
