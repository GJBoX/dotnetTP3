import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class EsbService {

    private final JmsTemplate jmsTemplate;

    @Autowired
    public EsbService(JmsTemplate jmsTemplate) {
        this.jmsTemplate = jmsTemplate;
    }

    public void sendToEsb(List<UserModel> userList) {
        jmsTemplate.convertAndSend("userQueue", userList);
    }
}

@Service
public class UserService {

    private final UserRepository userRepository;
    private final CardModelService cardModelService;
    private final EsbService esbService;

    public UserService(UserRepository userRepository, CardModelService cardModelService, EsbService esbService) {
        this.userRepository = userRepository;
        this.cardModelService = cardModelService;
        this.esbService = esbService;
    }

    public List<UserModel> getAllUsers() {
        List<UserModel> userList = new ArrayList<>();
        userRepository.findAll().forEach(userList::add);
        esbService.sendToEsb(userList); // Envoie les données au canal ESB
        return userList;
    }

}

