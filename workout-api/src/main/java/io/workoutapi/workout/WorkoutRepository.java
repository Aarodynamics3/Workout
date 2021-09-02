package io.workoutapi.workout;

import org.springframework.data.repository.CrudRepository;

public interface WorkoutRepository extends CrudRepository<Workout, String> {
	
}
