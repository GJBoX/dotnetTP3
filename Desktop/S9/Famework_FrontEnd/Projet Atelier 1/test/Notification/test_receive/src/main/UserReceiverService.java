import org.springframework.jms.annotation.JmsListener;
import org.springframework.stereotype.Service;

import test.Notification.MySpringBootAppApplication ;

import java.util.List;


@Service
public class UserReceiverService {

    @JmsListener(destination = "userQueue")
    public void receiveMessage(List<UserModel> userList) {
        // Traitez les données reçues
        System.out.println("Received users: " + userList);
    }
}
