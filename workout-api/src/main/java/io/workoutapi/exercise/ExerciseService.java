package io.workoutapi.exercise;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ExerciseService {
	
	@Autowired
	private ExerciseRepository exerciseRepository;
	
	public List<Exercise> getAllExercises() {
		List<Exercise> exercises = new ArrayList<Exercise>();
		exerciseRepository.findAll().forEach(exercises::add);
		return exercises;
	}
	
	public Exercise getExercise(String id) {
		return exerciseRepository.findById(id).get();
	}

	public void addExercise(Exercise exercise) {
		exerciseRepository.save(exercise);
	}

	public void updateExercise(Exercise exercise, String id) {
		exerciseRepository.save(exercise);
	}

	public void deleteExercise(String id) {
		exerciseRepository.deleteById(id);
	}
}
